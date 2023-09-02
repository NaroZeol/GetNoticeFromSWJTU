#!/bin/bash
curl -s http://xg.swjtu.edu.cn/web/Home/PushNewsList?Lmk7LJw34Jmu=010j.shtml > __notice__.html
if (($? != 0)); then
    echo "获取网页信息失败"
    return 1
fi
    echo "已获取网页信息"
    
cat __notice__.html | grep h4 -m 1 | ./markrm.o | grep '\S' |  sed 's/^[ \t]*//'  > msg.txt
if (($? != 0)); then
    echo "获取通知链接失败"
    return 1
fi
    echo "已获取通知链接"

cat  __notice__.html | grep -m 1 "h4" | ./webfix.o >> msg.txt
if (($? != 0)); then
    echo "获取通知标题失败"
    return 1
fi
    echo "已获取通知标题"


echo ' '
cat msg.txt
 
rm __notice__.html