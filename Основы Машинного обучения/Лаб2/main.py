import sys
from statistics import mean
from matplotlib import pyplot
import pandas
import math

data = pandas.read_excel('Data2.xlsx', sheet_name='Sheet1')  # читаем файл
data = data.loc[data['uzel'] != 'NaN']  # фильтруем все не заполненные строки

# print(data)

Nn = data['uzel'].tolist()  # спасок узлов
Nk = data['konec'].tolist()  # спасок концевых
letterClass = data['class'].tolist()  # список принадлежности к букве

letter = ['R', 'T', 'Q']  # массив суествующих букв
i = 0
unknown = []  # массив точек, для которых еще не определены буквы
while i < len(Nn):  # сканируем файл, известные точки рисуем сразу, индексы неизвестных сохраняем
    if letterClass[i] == letter[0]:
        pyplot.scatter(Nn[i], Nk[i], color='b')
    elif letterClass[i] == letter[1]:
        pyplot.scatter(Nn[i], Nk[i], color='r')
    elif letterClass[i] == letter[2]:
        pyplot.scatter(Nn[i], Nk[i], color='g')
    else:
        unknown.append(i)
    i += 1

if not unknown:  # если неизвестных нет, то рисуем plot и ничего не делаем в файле
    pyplot.show()
    sys.exit()
i = 0

R = []
u = []
uR = []
uT = []
uQ = []


# метод высчитывает все данные к неизвестной точке, которая передается через индекс, который мы запомнили
def calculate(unknownIndex):
    j = 0
    # потенциалы к точкам трех классов
    u1 = []
    u2 = []
    u3 = []

    while j < len(Nn):
        global R
        global u
        R.append(math.sqrt((Nn[unknownIndex] - Nn[j]) ** 2 + (Nk[unknownIndex] - Nk[j]) ** 2))  # радиусы
        u.append(1 / (1 + R[j] ** 2))  # потенциалы


# относим потенциалы по классам, но если попалась именно неизвестная точка, то ничего не произойдет
        if letterClass[j] == letter[0]:
            u1.append(u[j])
        elif letterClass[j] == letter[1]:
            u2.append(u[j])
        elif letterClass[j] == letter[2]:
            u3.append(u[j])
        j += 1

# средние потенциалы к каждому классу
    global uR
    global uT
    global uQ
    uR = [mean(u1)]
    uT = [mean(u2)]
    uQ = [mean(u3)]

# нормализация
    uSum = uR[0] + uT[0] + uQ[0]
    uR[0] /= uSum
    uT[0] /= uSum
    uQ[0] /= uSum

# присвоение точке класса
    if (uR > uT) and (uR > uQ):
        letterClass[unknownIndex] = 'R'
        pyplot.scatter(Nn[unknownIndex], Nk[unknownIndex], color='b')
    elif (uT > uQ) and (uT > uR):
        letterClass[unknownIndex] = 'T'
        pyplot.scatter(Nn[unknownIndex], Nk[unknownIndex], color='r')
    elif (uQ > uT) and (uQ > uR):
        letterClass[unknownIndex] = 'Q'
        pyplot.scatter(Nn[unknownIndex], Nk[unknownIndex], color='g')
    return

# просчитываем все точки
while i < len(unknown):
    calculate(unknown[i])
    i += 1
i = 0

# вводим полученные массивы в DataFrame для переноса в Ecxel
# сначала данные по точкам
df1 = pandas.DataFrame({
    'uzel': [Nn[i] for i in range(len(letterClass))],
    'konec': [Nk[i] for i in range(len(letterClass))],
    'class': [letterClass[i] for i in range(len(letterClass))],
    'R': [R[i] for i in range(len(letterClass))],
    'u': [u[i] for i in range(len(letterClass))]
})

# отдельно данные по потенциалам
df2 = pandas.DataFrame({
    'u(R)': [uR[i] for i in range(1)],
    'u(T)': [uT[i] for i in range(1)],
    'u(Q)': [uQ[i] for i in range(1)]
}, index=None)

# ввод
writer = pandas.ExcelWriter('Data2.xlsx', engine='xlsxwriter')
df1.to_excel(writer)
df2.to_excel(writer, startcol=7)

# рисование графика
workbook = writer.book
worksheet = writer.sheets['Sheet1']

chart = workbook.add_chart({'type': 'column'})
chart.add_series({
    'values': '=\'Sheet1\'!$I$2',
    "name": "u(R)"
})
chart.add_series({
    'values': '=\'Sheet1\'!$J$2',
    "name": "u(T)"
})
chart.add_series({
    'values': '=\'Sheet1\'!$K$2',
    "name": "u(Q)"
})

worksheet.insert_chart('H6', chart)
writer.save()

pyplot.show()
