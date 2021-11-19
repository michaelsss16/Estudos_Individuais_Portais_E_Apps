import requests;
url = "http://localhost:19061/Controlador"
option = input("0- Sair\n1- get\n 2-Post\n 3- put\n 4- delete")
while(option!= '0'):
	
	if (option == '1'):
		response = requests.get(url)
	if (option == '2'):
		nome = input("Nome: ")
		idade = input("Idade: ")
		sexo = input("Sexo: ")
		dado = {"Nome":nome , "Idade":idade, "Sexo":sexo}
		response = requests.post(url,json = dado)
	if (option == '3'):
		id = input("Id: ")
		nome = input("Nome: ")
		idade = input("Idade: ")
		sexo = input("Sexo: ")
		dado = {"Id": id, "Nome":nome , "Idade":idade, "Sexo":sexo}
		response = requests.put(url, json = dado)

	#Delete
	if (option == '4'):
		id = input("Id: ")
		response = requests.delete(url+"/"+str(id))

	print(response.status_code)
	print(response.content.decode("utf-8"))
	option = input("0- Sair\n1- get\n 2-Post\n 3- put\n 4- delete")
print("Fim do programa!")