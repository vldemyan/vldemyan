up=`uptime`
echo $up
la1=`echo $up | awk '{print $8}'`
la2=`echo $up | awk '{print $9}'`
la3=`echo $up | awk '{print $10}'`
echo $la1
echo $la2
echo $la3
la1_1=`echo $la1 | awk -F\, '{print $1}'`
la1_2=`echo $la1 | awk -F\, '{print $2}'`
echo $la1_1
echo $la1_2 
la1=$la1_1'.'$la1_2
echo $la1
    
#comment
    
exit
mysql -uroot -e 'create database if not exists vld;
use vld;
create table if not exists la_info(date_time DATETIME,
load_average1 float, load_average2 float, load_average3 float);
insert into la_info values(NOW(), 1, 2, 3);
select * from la_info;' 
