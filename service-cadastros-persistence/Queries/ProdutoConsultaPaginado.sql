select @paginacao
prod.id,
prod.descricao,
prod.validade,
prod.excluido,
prod.data_registro,
prod.data_alteracao,
prod.usuario_registro,
prod.usuario_alteracao
from produtos prod
where prod.excluido = 'f'
@filtros