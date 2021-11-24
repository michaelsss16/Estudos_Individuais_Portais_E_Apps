#Adicionar implementação para busca por id 
# Adicionar busca de lista de empreedimentos comprados pelo cliente


import json
import uuid
import requests

UrlCliente = "http://localhost:9555/API/Clientes"
UrlMoradia = "http://localhost:9555/API/Empreendimentos/Moradia"
UrlComercial = "http://localhost:9555/API/Empreendimentos/Comercial"

def get(Url):
		response = requests.get(Url)
		print(json.loads(response.content))
		print(response.status_code)
		return response.status_code

def getId(Url, id, mensagemDeSucesso, mensagemDeErro):
		response = requests.get(Url+'/'+id)
		if(response.status_code==200):
			print(mensagemDeSucesso)
			print(response.content.decode('utf-8'))
		else:
			print(mensagemDeErro)
		return response.status_code

def post(Url, dado, mensagemDeSucesso, mensagemDeErro):
	response = requests.post(Url, json = dado)
	if(response.status_code ==201):
		print(mensagemDeSucesso)
	else:
		print(mensagemDeErro)
	return response.status_code

def putCliente(UrlCliente, id, mensagemDeSucesso, mensagemDeErro):
	response = requests.get(UrlCliente+'/'+id)
	if(response.status_code !=200):
		print(mensagemDeErro)
		return response.status_code
	cliente = json.loads(response.content.decode('utf-8'))
	nome = input("Qual o novo nome? ")
	cpf = input("Qual o novo cpf? ")
	body = {"Id": id, "Nome": nome, "CPF": cpf, "Identificador":cliente['identificador']}
	response = requests.put(UrlCliente+'/'+id,  json = body)
	if(response.status_code ==204 ):
		print(mensagemDeSucesso)
	else:
		print(mensagemDeErro)
	return response.status_code

def delete(Url, id, mensagemDeSucesso, mensagemDeErro):
	response = requests.delete(Url+'/'+id)
	if(response.status_code ==204):
		print(mensagemDeSucesso)
	else:
		print(mensagemDeErro)
	return response.status_code

def obterDadosEmpreendimentoMoradia():
	nome = input("Nome: ")
	valor = input("Valor: ")
	numeroDeQuartos = input("Numero de quartos: ")
	empreendimento = {"Nome": nome, "Valor": valor, "NumeroDeQuartos":numeroDeQuartos}
	return empreendimento

def obterDadosEmpreendimentoComercial():
	nome = input("Nome: ")
	valor = input("Valor: ")
	area = input("Área: ")
	empreendimento = {"Nome": nome, "Valor": valor, "Area":area}
	return empreendimento

def obterDadosCliente():
	nome = input("Nome: ")
	cpf = input("CPF: ")
	guid = str(uuid.uuid4())
	client = {"Nome": nome, "CPF": cpf, "Identificador":guid}
	return client

def telaFuncionario():
	senha = input("Senha: ")
	if(senha != "admin"):
		return False
	print("\n\n0- Retornar a tela inicial\n 1- Listar todos os clientes\n2- Cadastrar novo cliente\n3- Atualizar informações de cliente\n 4- Deletar um cliente\n5- Buscar cliente por ID\n11- Listar empreendimentos de moradia \n12- Adicionar empreendimento de moradia \n13- Deletar empreendimento de moradia \n 16- Listar empreendimentos comerciais\n 17- Adicionar empreendimento comercial\n18- Deletar empreendimento comercial\n")
	while(1):
		option = input("Opção: ")
		if(option== '0'):
			break
		if(option == '1'):
			get(UrlCliente)
		if(option == "2"):
			dadosCliente = obterDadosCliente()
			post(UrlCliente, dadosCliente, "Cliente cadastrado com sucesso!","Erro ao cadastrar o cliente")
		if(option == '3'):
			id = input("Qual o id do cliente a ser modificado?")
			putCliente(UrlCliente, id,"Modificações realizadas com sucesso!","Erro ao tentar modificar  o cliente. \nVerifique o id do cliente.")
		if(option == '4'):
			id = input("Qual o id do cliente a ser deletado?")
			delete(UrlCliente, id, "Cliente deletado com sucesso", "Erro ao tentar deletar o cliente.")
		if(option == '5'):
			id = input("Qual o id do cliente que deseja obter informações?")
			getId(UrlCliente, id, "Informações do cliente:", "Não foi possível encontrar nenhum cliente com o id inserido.")
		if(option == '11'):
			get(UrlMoradia)
		if(option == '12'):
			moradia= obterDadosEmpreendimentoMoradia()
			post(UrlMoradia, moradia, "Empreendimento cadastrado com sucesso!", "Erro ao cadastrar o empreendimento.")
		if(option == '13'):
			id = input("Qual o id do empreendimento de moradia que deseja deletar? ")
			delete(UrlMoradia, id, "Empreendimento deletado com sucesso!", "Erro ao deletar o empreendimento.")
		if(option == '16'):
			get(UrlComercial)
		if(option == '17'):
			moradia= obterDadosEmpreendimentoComercial()
			post(UrlComercial, moradia, "Empreendimento cadastrado com sucesso!", "Erro ao cadastrar o empreendimento.")
		if(option == '18'):
			id = input("Qual o id do empreendimento comercial que deseja deletar? ")
			delete(UrlComercial, id, "Empreendimento deletado com sucesso!", "Erro ao deletar o empreendimento.")



def telaCliente():
	cpf = input("Digite o CPF: ")
	cliente = ""
	lista = json.loads(requests.get(UrlCliente).content.decode('utf-8'))
	for item in lista:
		if(str(item['cpf'])==str(cpf)):
			cliente = ("Nome: "+ str(item['nome']+ "\nCPF: "+str(item['cpf'])))
	if(cliente == ""):
		print("O CPF informado não corresponde a nenhum cliente")
	else:
		print("Informações do cliente:\n"+ cliente)
def telaEmpreendimento():
	print("Bem vindo ao catálogo de empreendimentos!")
	while(True):
		option = input("0- Retornar a tela inicial\n 1- Empreendimentos de Moradia\n2- Empreendimentos Comerciais\n")
		if(option=='0'):
			break
		if(option == '2'):
			lista = json.loads(requests.get(UrlComercial).content.decode('utf-8'))
			print("Nome | Área | Valor")
			for item in lista:
				print(item['nome'] +'|'+ str(item['area']) +'|'+ str(item['valor']))
		
		if(option == '1'):
			lista = json.loads(requests.get(UrlMoradia).content.decode('utf-8'))
			print("Nome | Número de Quartos | Valor")
			for item in lista:
				print(item['nome'] +'|'+ str(item['numeroDeQuartos']) +'|'+ str(item['valor']))

	return True

def main():
	print("Bem vindo ao portal MRV")
	while(1):
		option = input("1- Acesso de clientes\n2- Acesso de funcionário\n3- Empreendimentos\n0-Finalizar")
		if(option == '1'):
			telaCliente()
		if(option == "2"):
			telaFuncionario()
		if(option == '3'):
			telaEmpreendimento()
		if(option=='0'):
			break;
main()
