#!/bin/bash
if (($# == 0)); then
    num=3
else
    num=$1
fi

if ((num <= 0)); then
    return 0
fi


if (curl -s https://scai.swjtu.edu.cn/web/page-module.html?mid=B730BEB095B31840 > __notice__.html); then
    echo "已获取网页信息"
else
    echo "获取网页信息失败"
    return 1
fi

#第一个通知    
grep -m 1 --after-context=2 "list-top-item fl"  __notice__.html | ./markrm.o | grep '\S' | sed 's/^[ \t]*//' > msg.txt
grep -m 1 --after-context=2 "list-top-item fl"  __notice__.html | ./webfix.o >> msg.txt
if (($? != 0)); then
    echo "获取第1个通知失败"
    rm __notice__.html
    return 1
else
    echo "已获取第1个通知"
fi

((num -= 1))
if ((num <= 0)); then
    rm __notice__.html
    return 0
fi
#第二个通知

grep -m 1 --after-context=2 "list-top-item fr" __notice__.html | ./markrm.o | grep '\S' | sed 's/^[ \t]*//' >> msg.txt
if (($? != 0)); then
    echo "获取第2个通知失败"
    rm __notice__.html
    return 1
else
    echo "已获取第2个通知"
fi
grep -m 1 --after-context=2 "list-top-item fr" __notice__.html | ./webfix.o >> msg.txt
if (($? != 0)); then
    echo "获取第2个通知失败"
    rm __notice__.html
    return 1
else
    echo "已获取第2个通知"
fi

((num -= 1))
if ((num <= 0)); then
    rm __notice__.html
    return 0
fi

for ((i=1; i<= num; i++))
do  
    grep  --after-context=2 "info-wrapper fl" __notice__.html | sed -n "$[i*4-3],$[i*4-1]p" | ./markrm.o | grep '\S' | sed 's/^[ \t]*//' >> msg.txt
    grep  --after-context=2 "info-wrapper fl" __notice__.html | sed -n "$[i*4-3],$[i*4-1]p" | ./webfix.o >> msg.txt
    if (($? != 0)); then
        echo "获取第$((i + 2))个通知失败"
        rm __notice__.html
        return 1
    else
        echo "已获取第$((i + 2))个通知"
    fi
done

echo ' '
cat msg.txt 

rm __notice__.html