insert into usuario (
id,
descricao,
ativo
) 
values
(
@id,
@descricao,
@ativo
)
returning(id);