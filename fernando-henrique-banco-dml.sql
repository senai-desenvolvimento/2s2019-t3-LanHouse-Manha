use Lan_House

insert into Usuarios values('admin@email.com', '123456')

bulk insert Tipos_Equipamentos
from 'C:\Users\fernando.henrique\treinamento-razor-lanhouse\csv\tipo_equipamento.csv'
with (
	fieldterminator = ',',
	rowterminator = '\n',
	firstrow = 1,
	codepage = 'acp'
)

bulk insert Tipos_Defeitos
from 'C:\Users\fernando.henrique\treinamento-razor-lanhouse\csv\defeito.csv'
with (
	fieldterminator = ',',
	rowterminator = '\n',
	firstrow = 1,
	codepage = 'acp'
)

bulk insert Registros_Defeitos
from 'C:\Users\fernando.henrique\treinamento-razor-lanhouse\csv\registro_defeito.csv'
with (
	fieldterminator = ',',
	rowterminator = '\n',
	firstrow = 1,
	codepage = 'acp'
)

