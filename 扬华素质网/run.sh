#!/bin/bash
if (($# == 0)); then
    num=3
else
    num=$1
fi

if ((num <= 0)); then
    return 0
fi

curl -s http://xg.swjtu.edu.cn/web/Home/PushNewsList?Lmk7LJw34Jmu=010j.shtml > __notice__.html

cat /dev/null > msg.txt

for ((i=1; i<= num; i++))
do
    grep "h4" __notice__.html | sed -n  "$((i))p" | ./markrm.o | grep '\S' | sed 's/^[ \t]*//' >> msg.txt
    grep "h4" __notice__.html | sed -n  "$((i))p" | ./webfix.o >> msg.txt
done

rm __notice__.html
cat msg.txt