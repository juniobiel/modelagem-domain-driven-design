# Domain Driven Design

Repositório de estudos para aplicação dos princípios de DDD.

## Práticas abordadas

A principal abordagem é o Domain Driven Design, na qual a aplicação se embasa em conceitos teóricos e práticos.

Porém, há o emprego de técnicas avançadas tanto para o _scripting_ quanto para o funcionamento de aplicações corporativas e robustas.

Dentre estas técnicas pode-se destacar:

1. Agregação de Raízes (DDD)
1. Objetos de Valor (DDD)
1. Contextos Delimitados (DDD) 
1. Mensageria (Message Handler)
1. Event Sourcing
1. CQRS (Command Query Responsibility Segregation) - Segregação de responsabilidades entre leitura e escrita de dados.

## Packages
Pacotes instalados
### MediatR
[Mediatr](https://mediatr.io/) é um pacote para dar suporte ao processamento de mensagens e eventos.

O pacote implementa o padrão Mediator, facilitando a comunicação entre componentes, de maneira desacoplada.

O mediador é um objeto que age como intermediário. Os objetos enviam a mensagem para o mediador e este encaminha para os objetos apropriados.
    
Fonte: [refactoring.guru](https://refactoring.guru/pt-br/design-patterns/mediator#:~:text=O%20Mediator%20%C3%A9%20um%20padr%C3%A3o,apenas%20atrav%C3%A9s%20do%20objeto%20mediador.)

`install-package mediatr`


## Créditos
Curso [modelagem de domínios ricos](https://desenvolvedor.io/curso-online-modelagem-de-dominios-ricos)