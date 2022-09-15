# import libraries
import pandas as pd
import matplotlib.pyplot as plt

table = pd.read_excel('data.xlsx')
objectTypes = table.values[:, 2]
j = 0

for i in objectTypes:
    if i == 0:
        Rx = table.values[j, 0]
        Ry = table.values[j, 1]
        plt.plot(Rx, Ry, 'ro')
    if i == 1:
        Tx = table.values[j, 0]
        Ty = table.values[j, 1]
        plt.plot(Tx, Ty, 'bo')
    if i == 2:
        Qx = table.values[j, 0]
        Qy = table.values[j, 1]
        plt.plot(Qx, Qy, 'yo')
    j = j + 1
plt.axis([0, 5, 0, 5])
plt.show()

