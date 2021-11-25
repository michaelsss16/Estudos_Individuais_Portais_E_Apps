
import json
import uuid
import requests

UrlCliente = "http://localhost:9555/API/Clientes"
UrlMoradia = "http://localhost:9555/API/Empreendimentos/Moradia"
UrlComercial = "http://localhost:9555/API/Empreendimentos/Comercial"
# Testes de get all
response = requests.get(UrlCliente)


# Apresentação dos resultados 
print("Status code: "+ str(response.status_code))
print("Resposta: "+ response.content.decode('utf-8'))
