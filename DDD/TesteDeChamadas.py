
import json
import uuid
import requests

UrlCliente = "http://localhost:9555/API/Clientes"
UrlMoradia = "http://localhost:9555/API/Empreendimentos/Moradia"
UrlComercial = "http://localhost:9555/API/Empreendimentos/Comercial"

ClienteMichael = {"Nome": "Michael Da Silva", "CPF": 12345}
ClienteMichaelCompleto  = {"Nome": "Michael Da Silva Soares Dos Santos", "CPF": 12345, "Id": 0, "Identificador":"4dd3681b-850f-4e84-9197-56168d9a9e6b"}
CasaPequena = {"Nome": "Casa Pequena", "Valor": 120000, "QuantidadeDeQuartos": 2}
CasaPequenaCompleto = {"Nome": "Casa Pequenade dois quartos", "Valor": 120000, "QuantidadeDeQuartos": 2, "Id": 0}
LojaPequena = {"Nome": "Loja Pequena", "Valor": 200000, "Area": 100}
LojaPequenaCompleto = {"Nome": "Loja Pequena de 100m", "Valor": 200000, "Area": 100, "Id": 0}

print("Testes da API")

# Testes de get all
#response = requests.get(UrlCliente)
#response = requests.get(UrlMoradia)
#response = requests.get(UrlCliente)

#Testes de get by id
#response = requests.get(UrlCliente + '/0')
#response = requests.get(UrlMoradia+ '/0')
#response = requests.get(UrlComercial + '/0')
# Testes de post
#response = requests.post(UrlCliente, json = ClienteMichael)
#response = requests.post(UrlMoradia, json = CasaPequena)
#response = requests.post(UrlComercial, json = LojaPequena)

# Testes de put
#response = requests.put(UrlCliente, json = ClienteMichaelCompleto)
#response = requests.put(UrlMoradia, json = CasaPequenaCompleto)
#response = requests.put(UrlComercial, json = LojaPequenaCompleto)

# testes de delete
#response = requests.delete(UrlCliente + '/0')
#response = requests.delete(UrlMoradia+ '/1')
#response = requests.delete(UrlComercial + '/0')


# Apresentação dos resultados 
print("Status code: "+ str(response.status_code))
print("Resposta: "+ response.content.decode('utf-8'))
