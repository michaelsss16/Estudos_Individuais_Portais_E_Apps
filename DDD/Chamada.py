import requests
url = "http://localhost:9555/API/Clientes"
dado = {"Nome":"Michael", "CPF":"12345"}
#response = requests.get(url)
response = requests.post(url, json=dado)
print(response.status_code)
print(response.content.decode('utf-8'))