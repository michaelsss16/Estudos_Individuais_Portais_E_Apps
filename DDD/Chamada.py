import requests
url = "http://localhost:9555/API/Clientes"
dado = {"Nome":"Michael", "CPF":"12345"}
dado1 = {"Id":1, "Nome":"Michael da Silva", "CPF":"9876"}
#response = requests.get(url)
#response = requests.post(url, json=dado)
#response = requests.delete(url+"/0")
response = requests.put(url, json = dado1)
print(response.status_code)
print(response.content.decode('utf-8'))