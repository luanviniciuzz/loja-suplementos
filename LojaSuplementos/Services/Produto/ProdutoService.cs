﻿using LojaSuplementos.Data;
using LojaSuplementos.Dto.Produto;
using LojaSuplementos.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSuplementos.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly DataContext _context;
        private readonly string _sistema;
        public ProdutoService(DataContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }

        public async Task<ProdutoModel> BuscarProdutoPorId(int id)
        {
            try
            {
                var produto = await _context.Produtos.Include(x=> x.Categoria).FirstOrDefaultAsync(p => p.Id == id);

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            try
            {
                return await _context.Produtos.Include(c => c.Categoria).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto)
        {
            try
            {
                var caminhoImagem = GerarCaminhoArquivo(foto);
                var produto = new ProdutoModel {
                    Nome = criarProdutoDto.Nome,
                    Marca = criarProdutoDto.Marca,
                    Valor = criarProdutoDto.Valor,
                    CategoriaModelId = criarProdutoDto.CategoriaModelId,
                    Foto = caminhoImagem,
                    QuantidadeEstoque = criarProdutoDto.QuantidadeEstoque
                };

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> Editar(EditarProdutoDto editarProdutoDto, IFormFile? foto)
        {
            try 
            {
                var produto = await BuscarProdutoPorId(editarProdutoDto.Id);
                var nomeCaminhoImagem = "";
                if(foto != null)
                {
                    string caminhoCapaExixtente = _sistema + "\\imagem\\" + produto.Foto;

                    if (File.Exists(caminhoCapaExixtente)) {
                        File.Delete(caminhoCapaExixtente);
                    }
                    nomeCaminhoImagem = GerarCaminhoArquivo(foto);
                }

                produto.Nome = editarProdutoDto.Nome;
                produto.Marca = editarProdutoDto.Marca;
                produto.Valor = editarProdutoDto.Valor;
                produto.QuantidadeEstoque = editarProdutoDto.QuantidadeEstoque;
                produto.CategoriaModelId = editarProdutoDto.CategoriaModelId;
                
                if(nomeCaminhoImagem != "") {
                    produto.Foto = nomeCaminhoImagem;
                }

                _context.Update(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GerarCaminhoArquivo(IFormFile foto)
        {
            var codigo = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codigo + ".png";

            var caminhoParaSalvarImagens = _sistema + "\\imagem\\";

            if(!Directory.Exists(caminhoParaSalvarImagens))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            }

            using (var stream = File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
            {
                foto.CopyToAsync(stream).Wait();
            }

            return nomeCaminhoImagem;
        }
    }
}
