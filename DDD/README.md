# Informações gerais sobre projeto
API desenvolvida a partir do modelo apresentado, seguindo diretrizes do domain driven design, com simulação  do sistema de compra e venda de empreendimentos imobiliários  e gestão de clientes.
Pontos de desenvolvimento :
- Adicionar retorno de dados para busca por id 
- Implementar objetos de resposta para todos os métodos de tratamento de objetos
- Validar os códigos de retorno
- Fazer os ajustes no código python para todos os métodos do sistema


- realizar tratamento de erro para o serviço e repositorio de cliente 
- Utilizar a classe de configuração/dependenciInjection para implementar a injeção de dependência 
- Validar a necessidade de uso dos atributos de json

1. Camada de aplicação: responsável pelo projeto principal, pois é onde será desenvolvido os controladores e serviços da API. Tem a função de receber todas as requisições e direcioná-las a algum serviço para executar uma determinada ação.
Possui referências das camadas Service e Domain.
2. Camada de domínio: responsável pela implementação de classes/modelos, as quais serão mapeadas para o banco de dados, além de obter as declarações de interfaces, constantes, DTOs (Data Transfer Object) e enums.
3. Camada de serviço: seria o “coração” do projeto, pois é nela que é feita todas as regras de negócio e todas as validações, antes de persistir os dados no banco de dados.
Possui referências das camadas Domain, Infra.Data e Infra.CrossCutting.
4. Camada de infraestrutura: é dividida em duas sub-camadas
- Data: realiza a persistência com o banco de dados, utilizando, ou não, algum ORM.
- Cross-Cutting: uma camada a parte que não obedece a hierarquia de camada. Como o próprio nome diz, essa camada cruza toda a hierarquia. Contém as funcionalidades que pode ser utilizada em qualquer parte do código, como, por exemplo, validação de CPF/CNPJ, consumo de API externa e utilização de alguma segurança.
Possui referências da camada Domain.
