#!/bin/bash
if (($# == 0)); then
    num=3
else
    num=$1
fi

if ((num <= 0)); then
    return 0
fi

curl -s http://jwc.swjtu.edu.cn/vatuu/WebAction?setAction=newsList > __notice__.html

cat /dev/null > msg.txt

for ((i=1; i<= num; i++))
do
    grep --after-context=2 "littleResultDiv" __notice__.html | sed -n  "$((i*4-3)),$((i*4-1))p" | ./markrm.o | grep '\S' | sed 's/^[ \t]*//' >> msg.txt
    grep --after-context=2 "littleResultDiv" __notice__.html | sed -n  "$((i*4-3)),$((i*4-1))p" | ./webfix.o >> msg.txt
done

rm __notice__.html
cat msg.txt