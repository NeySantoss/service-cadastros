﻿SELECT
ID,
DESCRICAO,
VALIDADE,
EXCLUIDO,
DATA_REGISTRO,
DATA_ALTERACAO,
USUARIO_REGISTRO,
USUARIO_ALTERACAO
FROM PRODUTOS prod
WHERE prod.excluido = 'F' 
@filtros