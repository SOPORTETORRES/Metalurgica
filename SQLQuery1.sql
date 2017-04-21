select hd.Obra ,  Max(p.Fecha)  from piezas p , HojaDespiece hd 
where Id_Hd =hd.id
group by hd.Obra 
order  by  2 desc