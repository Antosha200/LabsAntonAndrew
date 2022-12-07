import math

from PIL import Image, ImageDraw
import numpy as np
from matplotlib import pyplot as plt
from mpl_toolkits.mplot3d import Axes3D as ax
import pandas as pd
import os
from os import listdir

lke = pd.read_excel('data.xlsx', sheet_name='Лист1')
Nh1 = lke['Nh1'].tolist()
Nh2 = lke['Nh2'].tolist()
Nv = lke['Nv'].tolist()
letterClass = lke['class'].tolist()
R = []
u = []

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

f = 0
fkol = 0
skol = 0
thkol = 0

folder_dir = ".\Pictures"
for images in os.listdir(folder_dir):

    # check if the image ends with png
    if (images.endswith(".png")):
        # Обработка изображения
        image = Image.open(folder_dir + '/' + images)
        idraw = ImageDraw.Draw(image)

        arr = np.asarray(image, dtype='uint8')
        # print(arr)
        h1 = 0

        i = 0
        while i < 50:
            if list(arr[39, i]) == [0, 0, 0] and list(arr[39, i + 1]) != [0, 0, 0]:
                h1 = h1 + 1
            i += 1
        h2 = 0
        i = 0
        while i < 50:
            if list(arr[18, i]) == [0, 0, 0] and list(arr[18, i + 1]) != [0, 0, 0]:
                h2 = h2 + 1
            i += 1
        v = 0
        i = 0
        while i < 17:
            if list(arr[i, 30]) == [0, 0, 0] and list(arr[i + 1, 30]) != [0, 0, 0]:
                v = v + 1
            i += 1

        idraw.rectangle((0, 39, 50, 39), fill='blue')  # horizontal
        idraw.rectangle((0, 18, 50, 18), fill='purple')  # horizontal2
        idraw.rectangle((30, 0, 30, 17), fill='red')  # vertical

        # image.show()
        f += 1
        image.save(f"./Pictures with zonds/image{f}.png")

        Nh1.append(h1)
        Nh2.append(h2)
        Nv.append(v)

        if thkol < 5:
            ax.scatter(Nh1[thkol], Nh2[thkol], Nv[thkol], c='g')
            thkol += 1
            letterClass.append("third")
        elif skol < 5:
            ax.scatter(Nh1[skol + thkol], Nh2[skol + thkol], Nv[skol + thkol], c='b')
            skol += 1
            letterClass.append("second")
        else:
            ax.scatter(Nh1[fkol + skol + thkol], Nh2[fkol + skol + thkol], Nv[fkol + skol + thkol], c='r')
            fkol += 1
            letterClass.append("first")

df = pd.DataFrame({'Nh1': [Nh1[i] for i in range(len(letterClass))],
                   'Nh2': [Nh2[i] for i in range(len(letterClass))],
                   'Nv': [Nv[i] for i in range(len(letterClass))],
                   'class': [letterClass[i] for i in range(len(letterClass))]})

df.to_excel('data.xlsx', sheet_name='Лист1', index=False)

# image = Image.open(images)
# idraw = ImageDraw.Draw(image)
j = 0

for images in os.listdir():
    if (images.endswith(".png")):
        image = Image.open(images)
        idraw = ImageDraw.Draw(image)

        arr = np.asarray(image, dtype='uint8')

        i = 0
        h1 = 0
        while i < 50:
            if list(arr[39, i]) == [0, 0, 0] and list(arr[39, i + 1]) != [0, 0, 0]:
                h1 = h1 + 1
            i += 1
        h2 = 0
        i = 0
        while i < 50:
            if list(arr[18, i]) == [0, 0, 0] and list(arr[18, i + 1]) != [0, 0, 0]:
                h2 = h2 + 1
            i += 1
        v = 0
        i = 0
        while i < 17:
            if list(arr[i, 30]) == [0, 0, 0] and list(arr[i + 1, 30]) != [0, 0, 0]:
                v = v + 1
            i += 1

        Nh1.append(h1)
        Nh2.append(h2)
        Nv.append(v)
        j = 0

        for i in range(len(letterClass)):
            R.append(math.sqrt((Nh1[len(Nh1) - 1] - Nh1[i]) ** 2 + (Nh2[len(Nh1) - 1] - Nh2[i]) ** 2))
            u.append(1 / (1 + R[i] ** 2))
            j = j + 1

        j = j - 1
        R.append(R[j])
        u.append(u[j])

        ##

        l = (Nh1[len(letterClass)] - Nh1[0]) ** 2 + (Nh2[len(letterClass)] - Nh2[0]) ** 2 + (
        Nv[len(letterClass)] - Nv[0]) ** 2
        lenght = [i for i in range(len(letterClass))]

        k = [0, -2, -2]

        k[0] = 0
        i = 0
        while i < len(letterClass):
            lenght[i] = (Nh1[len(Nh1) - 1] - Nh1[i]) ** 2 + (Nh2[len(Nh2) - 1] - Nh2[i]) ** 2 + (
                        Nv[len(Nv) - 1] - Nv[i]) ** 2
            if lenght[i] < l:
                l = lenght[i]
                k[0] = i
            i += 1

        if k[0] != 0:
            l = lenght[0]
            k[1] = 0
        else:
            l = lenght[1]
            k[1] = 1

        i = 0
        while i < len(letterClass):
            if lenght[i] < l:
                if i != k[0]:
                    l = lenght[i]
                    k[1] = i
                    print(k[1])
            i += 1

        if k[0] != 0 and k[1] != 0:
            l = lenght[0]
            k[2] = 0
        elif k[0] != 1 and k[1] != 1:
            l = lenght[1]
            k[2] = 1
        else:
            l = lenght[2]
            k[2] = 2
        i = 0
        while i < len(letterClass):
            if lenght[i] < l:
                if i != k[0] and i != k[1]:
                    l = lenght[i]
                    k[2] = i
            i += 1
        print(k[0], k[1], k[2])
        letter = ["first", "second", "third"]
        l = len(Nh1) - 1
        f = s = th = 0
        for n in range(0, 3):
            if letterClass[k[n]] == letter[0]:
                f += 1
                ax.plot([Nh1[l], Nh1[k[n]]], [Nh2[l], Nh2[k[n]]], [Nv[l], Nv[k[n]]], c='r')
            if letterClass[k[n]] == letter[1]:
                s += 1
                ax.plot([Nh1[l], Nh1[k[n]]], [Nh2[l], Nh2[k[n]]], [Nv[l], Nv[k[n]]], c='b')
            if letterClass[k[n]] == letter[2]:
                th += 1
                ax.plot([Nh1[l], Nh1[k[n]]], [Nh2[l], Nh2[k[n]]], [Nv[l], Nv[k[n]]], c='g')

        if f >= s and f >= th:
            ax.scatter(Nh1[l], Nh2[l], Nv[l], c='r')
            letterClass.append("first")
        elif s >= f and s >= th:
            ax.scatter(Nh1[l], Nh2[l], Nv[l], c='b')
            letterClass.append("second")
        else:
            ax.scatter(Nh1[l], Nh2[l], Nv[l], color='g')
            letterClass.append("third")

        idraw.rectangle((0, 39, 50, 39), fill='blue')  # horizontal
        idraw.rectangle((0, 18, 50, 18), fill='purple')  # horizontal2
        idraw.rectangle((30, 0, 30, 17), fill='red')  # vertical
        image.show()

        f += 1
        image.save(f"./Pictures with zonds/image{f}.png")
        lenght.append(0)

        df = pd.DataFrame({'Nh1': [Nh1[i] for i in range(0, len(letterClass))],
                           'Nh2': [Nh2[i] for i in range(0, len(letterClass))],
                           'Nv': [Nv[i] for i in range(0, len(letterClass))],
                           'class': [letterClass[i] for i in range(0, len(letterClass))],
                           #'l': [lenght[i] for i in range(len(letterClass))],
                           'R': [R[i] for i in range(len(letterClass))],
                           'u': [u[i] for i in range(len(letterClass))]})

        df.to_excel('data.xlsx', sheet_name='Лист1', index=False)

plt.show()
