from statistics import mean
from matplotlib import pyplot
import pandas
import math

data = pandas.read_excel('data.xlsx', sheet_name='Sheet1')

arrayNode = data['Node'].tolist()
arrayEnd = data['end'].tolist()
objectType = data['class'].tolist()
R = []
u = []
u1 = []
u2 = []
u3 = []

object = ['R', 'T', 'Q']
i = 0
unknown = 0
while i < len(arrayNode):
    if objectType[i] == object[0]:
        pyplot.scatter(arrayNode[i], arrayEnd[i], color='b')
    elif objectType[i] == object[1]:
        pyplot.scatter(arrayNode[i], arrayEnd[i], color='c')
    elif objectType[i] == object[2]:
        pyplot.scatter(arrayNode[i], arrayEnd[i], color='k')
    elif objectType[i] == ' ':
        unknown += 1
        pyplot.scatter(arrayNode[i], arrayEnd[i], color='r')
    i += 1

if unknown != 0:
    i = 0
else:
    pyplot.show()
    raise SystemExit

while i < len(arrayNode):
    R.append(math.sqrt((arrayNode[len(arrayNode) - 1] - arrayNode[i]) ** 2 +
                       (arrayEnd[len(arrayNode) - 1] - arrayEnd[i]) ** 2))  # math radius
    u.append(1 / (1 + R[i] ** 2))  # fi(x,1) = 1/1+r^2

    if objectType[i] == object[0]:
        u1.append(u[i])
    elif objectType[i] == object[1]:
        u2.append(u[i])
    elif objectType[i] == object[2]:
        u3.append(u[i])

    i += 1

uR = [mean(u1)]
uT = [mean(u2)]
uQ = [mean(u3)]

if (uR > uT) and (uR > uQ):
    objectType[i - 1] = 'R'
elif (uQ > uT) and (uQ > uR):
    objectType[i - 1] = 'T'
elif (uT > uQ) and (uT > uR):
    objectType[i - 1] = 'Q'

i = 0

while i < len(arrayNode) - 1:
    uR.append(' ')
    uT.append(' ')
    uQ.append(' ')
    i += 1

df = pandas.DataFrame({
    'Node': [arrayNode[i] for i in range(len(objectType))],
    'end': [arrayEnd[i] for i in range(len(objectType))],
    'class': [objectType[i] for i in range(len(objectType))],
    'R': [R[i] for i in range(len(objectType))],
    'u': [u[i] for i in range(len(objectType))],
    ' ': [' ' for i in range(len(objectType))],
    'u(R)': [uR[i] for i in range(len(objectType))],
    'u(T)': [uT[i] for i in range(len(objectType))],
    'u(Q)': [uQ[i] for i in range(len(objectType))]
})

writer = pandas.ExcelWriter('data.xlsx', engine='xlsxwriter')
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

pyplot.show()
