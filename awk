easyit@easyit-vld:~$ echo "qwe" | sed s/w/www/
qwwwe
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./
0.11,
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g
0.11.
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/.$//g
0.11
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/.//g

easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\.//g

easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g
0.11.
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\./l/g
lllll
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/./l/g
lllll
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\./l/g
lllll
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\./l/
l.11.
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\\./l/
0l11.
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\\.//
011.
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\\.//g
011
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\\.$//g
0.11
easyit@easyit-vld:~$ echo "qwe" | sed s/./T/
Twe
easyit@easyit-vld:~$ echo "qwe" | sed s/./T/g
TTT
easyit@easyit-vld:~$ echo "qwe" | sed s/q/T/g
Twe
easyit@easyit-vld:~$ echo "qwe" | sed s/w/T/g
qTe
easyit@easyit-vld:~$ echo "qwe" | sed s/e/T/g
qwT
easyit@easyit-vld:~$ echo "qwe" | sed s/^q/T/g
Twe
easyit@easyit-vld:~$ echo "qwe" | sed s/^w/T/g
qwe
easyit@easyit-vld:~$ echo "qwe" | sed s/w$/T/g
qwe
easyit@easyit-vld:~$ echo "qwe" | sed s/e$/T/g
qwT
easyit@easyit-vld:~$ echo "qwe" | sed s/we$/T/g
qT
easyit@easyit-vld:~$ echo "qwe" | sed s/qwe$/T/g
T
easyit@easyit-vld:~$ echo "qwe " | sed s/qwe$/T/g
qwe 
easyit@easyit-vld:~$ echo "qwe " | sed s/^qwe/T/g
T 
easyit@easyit-vld:~$ echo "qwe akdushfkahdjkha" | sed s/^qwe/T/g
T akdushfkahdjkha
easyit@easyit-vld:~$ echo "qwe qweqweq" | sed s/^qwe/T/g
T qweqweq
easyit@easyit-vld:~$ echo "qwe asdzxc qwe" | sed s/qwe$/T/g
qwe asdzxc T
easyit@easyit-vld:~$ echo "qwe asdzxc qwe" | sed s/qwe$/T/
qwe asdzxc T
easyit@easyit-vld:~$ echo "qwe asdzxc qwe" | sed s/qwe/T/
T asdzxc qwe
easyit@easyit-vld:~$ echo "qwe asdzxc qwe" | sed s/qwe$/T/
qwe asdzxc T
easyit@easyit-vld:~$ echo "0,11," | sed s/,/./g | sed s/\\.$//g
0.11
easyit@easyit-vld:~$ 

