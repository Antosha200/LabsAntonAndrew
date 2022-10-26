# import libraries
import math
import pandas as pd
import matplotlib.pyplot as plt
from statistics import mean

table = pd.read_excel('data.xlsx')
objectTypes = table.values[:, 3]
print(objectTypes)
j = 0
R = []
u = []
u1 = []
u2 = []
u3 = []
letterClass = table['class'].tolist()

for i in objectTypes:
    if i == 0:
        Rx = table.values[j, 1]
        Ry = table.values[j, 2]
        plt.plot(Rx, Ry, 'ro')
    if i == 1:
        Tx = table.values[j, 1]
        Ty = table.values[j, 2]
        plt.plot(Tx, Ty, 'bo')
    if i == 2:
        Qx = table.values[j, 1]
        Qy = table.values[j, 2]
        plt.plot(Qx, Qy, 'yo')
    j = j + 1
plt.axis([0, 5, 0, 5])

# Lab2

nodeArray = table['Node'].tolist()
endArray = table['end'].tolist()

for i in objectTypes:
    R.append(math.sqrt(
        (nodeArray[len(nodeArray) - 1] - nodeArray[i]) ** 2 + (endArray[len(nodeArray) - 1] - endArray[i]) ** 2))
    u.append(1 / (1 + R[i] ** 2))
    if i == 0:
        print(0)
        u1.append(u[i])
    elif i == 1:
        print(1)
        u2.append(u[i])
    elif i == 2:
        print(2)
        u3.append(u[i])

uR = [mean(u1)]
uT = [mean(u2)]
uQ = [mean(u3)]

print(letterClass)

for i in objectTypes:
    if (uR > uT) and (uR > uQ):
        letterClass[i - 1] = 0
    elif (uQ > uT) and (uQ > uR):
        letterClass[i - 1] = 1
    elif (uT > uQ) and (uT > uR):
        letterClass[i - 1] = 2
    uR.append(' ')
    uT.append(' ')
    uQ.append(' ')


df = pd.DataFrame({
    'Node': [nodeArray[i] for i in range(len(letterClass))],
    'end': [endArray[i] for i in range(len(letterClass))],
    'class': [letterClass[i] for i in range(len(objectTypes))],
    'R': [R[i] for i in range(len(objectTypes))],
    'u': [u[i] for i in range(len(objectTypes))],
    ' ': [' ' for i in range(len(objectTypes))],
    'u (R)': [uR[i] for i in range(len(letterClass))],
    'u (T)': [uT[i] for i in range(len(objectTypes))],
    'u (Q)': [uQ[i] for i in range(len(objectTypes))]
})

writer = pd.ExcelWriter('data.xlsx', engine='xlsxwriter')
df.to_excel(writer)

workbook = writer.book
worksheet = writer.sheets['Sheet1']

chart = workbook.add_chart({'type': 'column'})
chart.add_series({
    'values': '=\'Sheet1\'!$H$2',
    "name": "u(S)"
})
chart.add_series({
    'values': '=\'Sheet1\'!$I$2',
    "name": "u(Э)"
})
chart.add_series({
    'values': '=\'Sheet1\'!$J$2',
    "name": "u(L)"
})

worksheet.insert_chart('H6', chart)
writer.save()

plt.show()
