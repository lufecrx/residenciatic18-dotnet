using Interface.pagamentos;
using Interface.usuarios;

var cartaoCredito = new CartaoCredito();
var transferenciaBancaria = new TransferenciaBancaria();
var emDinheiro = new EmDinheiro();

// Criando cliente ficticio
var cliente = new Cliente();

cliente.RealizarPagamento(cartaoCredito);
cliente.RealizarPagamento(transferenciaBancaria);
cliente.RealizarPagamento(emDinheiro);

