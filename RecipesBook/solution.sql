select coalesce(a[1], null) as left_title, coalesce(a[2], NULL) as right_title from 
(select   regexp_split_to_array(string_agg(coalesce(title, 'NULL'), ',') , ',')
  from recipes a  right join
 generate_series(0, (select max(page_no) from recipes))  b
 on   a.page_no = b
  group by b/2
  order by b/2 ) as dt(a)