# GeekBurger-Promotion


## linke para o swagger
https://geekburgerpromotion.azurewebsites.net/swagger/index.html


<img width="800" src="https://github.com/AndersonPull/GeekBurger-Promotion/blob/main/imgs/new.jpeg">

## Definição dos Contratos: APIs - WebAPIs 
PromotionRequest 
{ 
  "id": 0, 
  "storeName": "Paulista", 
  "name": "A grande promocao", 
  "image": " A_grande_promocao.jpg", 
  "productsId": "2,3", 
  "price": 10.0 
} 

PromotionResponse 
[ 
  { 
    "id": 0, 
    "storeName": "Paulista", 
    "name": "A grande promocao", 
    "image": " A_grande_promocao.jpg", 
    "products": [ 
      { 
        "id": 2, 
        "name": "Quarterão" 
      }, 
      { 
        "id": 3, 
        "name": "McChicken" 
      } 
    ], 
    "price": 10.0 
  } 
] 

## Definição dos Contratos: Payload de mensagens -  ServiceBus

{ 
    "id": 0, 
    "storeName": "Paulista", 
    "name": "A grande promocao", 
    "image": " A_grande_promocao.jpg", 
    "products": [ 
      { 
        "id": 2, 
        "name": "Quarterão" 
      }, 
      { 
        "id": 3, 
        "name": "McChicken" 
      } 
    ], 
    "price": 10.0, 
    "PromotionState": 2 
  } 
