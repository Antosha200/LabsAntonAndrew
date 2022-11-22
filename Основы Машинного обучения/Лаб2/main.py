from statistics import mean
from matplotlib import pyplot
import pandas
import math

data = pandas.read_excel(
    'Data.xlsx', sheet_name='Sheet1')

Nn = data['uzel'].tolist()
Nk = data['konec'].tolist()
letterClass = data['class'].tolist()

letter = ['R', 'T', 'Q']
i = 0
unknown = 0
while i < len(Nn):
    if letterClass[i] == letter[0]:
        pyplot.scatter(Nn[i], Nk[i], color='y')
    elif letterClass[i] == letter[1]:
        pyplot.scatter(Nn[i], Nk[i], color='g')
    elif letterClass[i] == letter[2]:
        pyplot.scatter(Nn[i], Nk[i], color='b')
    elif letterClass[i] == ' ':
        unknown += 1
        pyplot.scatter(Nn[i], Nk[i], color='r')
    i += 1

if unknown != 0:
    i = 0
else: 
    pyplot.show()
    raise SystemExit


R = []
u = []
u1 = []
u2 = []
u3 = []

while i < len(Nn):
    R.append(math.sqrt((Nn[len(Nn)-1]-Nn[i])**2 + (Nk[len(Nn)-1]-Nk[i])**2))
    u.append(1/(1+R[i]**2))

    if letterClass[i] == letter[0]:
        u1.append(u[i])
    elif letterClass[i] == letter[1]:
        u2.append(u[i])
    elif letterClass[i] == letter[2]:
        u3.append(u[i])

    i += 1

uS = [mean(u1)]
uЭ = [mean(u2)]
uL = [mean(u3)]

if (uS > uЭ) and (uS > uL):
        letterClass[i-1]='R'
elif (uL > uЭ) and (uL > uS):
        letterClass[i-1]='T'
elif (uЭ > uL) and (uЭ > uS):
        letterClass[i-1]='Q'

i=0

while i < len(Nn)-1:
    uS.append(' ')
    uЭ.append(' ')
    uL.append(' ')
    i += 1

df = pandas.DataFrame({
                       'uzel': [Nn[i] for i in range(len(letterClass))],
                       'konec': [Nk[i] for i in range(len(letterClass))],
                       'class': [letterClass[i] for i in range(len(letterClass))],
                       'R': [R[i] for i in range(len(letterClass))],
                       'u': [u[i] for i in range(len(letterClass))],
                       ' ': [' ' for i in range(len(letterClass))],
                       'u(R)': [uS[i] for i in range(len(letterClass))],
                       'u(T)': [uЭ[i] for i in range(len(letterClass))],
                       'u(Q)': [uL[i] for i in range(len(letterClass))]
                       })

writer = pandas.ExcelWriter('Data.xlsx', engine='xlsxwriter')
df.to_excel(writer)

workbook = writer.book
worksheet = writer.sheets['Sheet1']

chart = workbook.add_chart({'type': 'column'})
chart.add_series({
    'values': '=\'Sheet1\'!$H$2',
    "name": "u(R)"
})
chart.add_series({
    'values': '=\'Sheet1\'!$I$2',
    "name": "u(T)"
})
chart.add_series({
    'values': '=\'Sheet1\'!$J$2',
    "name": "u(Q)"
})

worksheet.insert_chart('H6', chart)
writer.save()

pyplot.show()
