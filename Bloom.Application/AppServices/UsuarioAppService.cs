using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Bloom.BLL.Enums;
using Bloom.BLL.RepositoriesInterfaces;

namespace Bloom.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IAmizadeService _amizadeService;
        private readonly IUsuarioService _usuarioService;
        private readonly ISerieService _serieService;
        private readonly IFilmeService _filmeService;
        private readonly ILivroService _livroService;

        public UsuarioAppService(IAmizadeService amizadeService, IUsuarioService usuarioService, ISerieService serieService, IFilmeService filmeService, ILivroService livroService)
        {
            _amizadeService = amizadeService;
            _usuarioService = usuarioService;
            _serieService = serieService;
            _filmeService = filmeService;
            _livroService = livroService;

        }
        //Buscas
        public ResponseUtil GetUserByUsername(string username)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Usuario user = _usuarioService.GetByUsername(username);
                if (user == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                resposta.Resultado = user;
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }

        public Usuario GetUserByUsernameConvite(string username)
        {
    
                Usuario user = _usuarioService.GetByUsername(username);
                 return user;
             
        }

        //Perfil
        public ResponseUtil GetInformacoesUser(string userEmail)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Usuario user = _usuarioService.GetByEmail(userEmail);
                if (user == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                resposta.Resultado = user;
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public ResponseUtil AtualizarUsuario(UpdateUserModel model)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Usuario user = _usuarioService.GetByEmail(model.userEmail);
                if (user == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                if (model.Foto != null)
                {
                    ResponseUtil resultImg = DownloadImage(model.Foto, user.UsuarioId.ToString()).Result;
                    if (resultImg.Sucesso)
                    {
                        user.Foto = resultImg.Resultado.ToString();
                    }
                }

                if (model.Nome != null)
                {
                    user.Nome = model.Nome;
                }
                if (model.Username != null)
                {
                    if (!_usuarioService.ValidarUsername(model.Username))
                    {
                        resposta.Resultado = "Este username já está sendo usado";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    else
                    {
                        user.Username = model.Username;
                    }
                }
                if (model.Estado != null)
                {
                    user.Estado = model.Estado;
                }
                if (model.Cidade != null)
                {
                    user.Cidade = model.Cidade;
                }
                if (model.DataDeNascimento != null)
                {
                    user.DataDeNascimento = model.DataDeNascimento;
                }
                _usuarioService.Edit(user);

                resposta.Resultado = user;
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public async Task<ResponseUtil> DownloadImage(IFormFile file, string userId)
        {
            var response = new ResponseUtil();

            try
            {
                string dir = Directory.GetCurrentDirectory();
                dir += ".BLL";
                //dir = dir.Replace("Bloom", "Bloom.BLL");
                string insideDir = "/Assets/MoviesImages/";
                string path = dir + insideDir;


                string[] subs = file.FileName.Split('.');
                var fileName = $"{userId}.{subs[1]}";

                string filePath = Path.Combine(path, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                response.Sucesso = true;
                //response.Resultado = "Bloom/Bloom.BLL" + insideDir + fileName;
                response.Resultado = fileName;
            }
            catch (Exception e)
            {
                response.Resultado = "Erro ao adicionar a imagem";
                response.Sucesso = false;
            }

            return response;
        }

        //Admin
        public ResponseUtil GraficoUsuariosByEstado()
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                List<Usuario> usersList = _usuarioService.GetAllUsuarios();
                if (usersList == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                List<GraficoResponse> responseList = new List<GraficoResponse>();
                var usersByState = usersList.GroupBy(x => x.Estado);
                
                foreach( var x in usersByState)
                {
                    GraficoResponse grafico = new GraficoResponse
                    {
                        Numero = x.Count(),
                        Estado = x.FirstOrDefault().Estado
                    };
                    responseList.Add(grafico);
                }
                resposta.Resultado = responseList;
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public ResponseUtil GetMaisConectados(int Take)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                List<Usuario> usersList = _usuarioService.GetAllUsuarios();
                if (usersList == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                List<MaisConectadosResponse> maisConectadosResponses = new List<MaisConectadosResponse>();
                usersList.ForEach(x =>
               {
                   List<Amizade> amizadesList = _amizadeService.GetMeusAmigos(x.UsuarioId);
                   MaisConectadosResponse maisConectadoResponse = new MaisConectadosResponse
                   {
                       NumeroDeAmigos = amizadesList.Count,
                       Username = x.Username,
                       Foto = x.Foto
                   };

                   maisConectadosResponses.Add(maisConectadoResponse);
               });

                resposta.Resultado = maisConectadosResponses.OrderByDescending(x => x.NumeroDeAmigos).Take(Take);
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public ResponseUtil GetMediaDeAmigos()
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Usuario> AllUsersList = _usuarioService.GetAllUsuarios();
                List<int> numeroAmigosList = new List<int>();

                AllUsersList.ForEach(x =>
                {
                    var numero = _amizadeService.GetMeusAmigos(x.UsuarioId);
                    numeroAmigosList.Add(numero.Count);
                });
                var media = 0;
                numeroAmigosList.ForEach(x =>
                {
                    media += x;
                });
                var mediaTotal = media / AllUsersList.Count;
                resposta.Sucesso = true;
                resposta.Resultado = mediaTotal;

            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Resultado = false;
            }
            return resposta;
        }

        //Serie
        public ResponseUtil GetSeriesParaAprovacao()
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                var series = _serieService.GetSeriesParaAprovacao();
                if (series == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhuma serie cadastrado";
                    return resposta;
                };

                List<SerieResponse> seriesResponses = new List<SerieResponse>();
                foreach (var serie in series)
                {
                    Usuario usuario = _usuarioService.GetById(serie.UsuarioId);
                    SerieResponse serieResponse = new SerieResponse
                    {
                        Diretor = serie.Diretor,
                        Ano = serie.Ano,
                        Elenco = serie.Elenco,
                        Titulo = serie.Titulo,
                        Genero = serie.Genero,
                        Pais = serie.Pais,
                        Username = usuario.Username,
                        NumeroDeTemporadas = serie.NumeroDeTemporadas,
                        Classificacao = serie.Classificacao,
                        Id = serie.Id
                    };
                    seriesResponses.Add(serieResponse);

                }
                resposta.Sucesso = true;
                resposta.Resultado = seriesResponses;
            }
            catch(Exception e)
            {
                resposta.Resultado = e;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil AprovarRecusarSerie(Guid serieId,bool Aprovar)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Serie serie = _serieService.GetById(serieId);
                if(serie == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Esta série não existe";
                    return resposta;
                }
                if (Aprovar)
                {
                    serie.Status = StatusAvaliacao.Aprovado;
                    _serieService.Edit(serie);
                    resposta.Resultado = "Série aprovada!";
                }
                if (!Aprovar)
                {
                    serie.Status = StatusAvaliacao.Rejeitado;
                    _serieService.Edit(serie);
                    resposta.Resultado = "Série recusada!";
                }
                resposta.Sucesso = true;

            }
            catch(Exception e)
            {
                resposta.Resultado = e;
                resposta.Sucesso = false;
            }
            return resposta;
        }

        //Filme
        public ResponseUtil GetFilmesParaAprovacao()
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                var filmes = _filmeService.GetFilmesParaAprovacao();
                if (filmes == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum filme cadastrado";
                    return resposta;
                };

                List<FilmeResponse> filmeResponses = new List<FilmeResponse>();
                foreach (var filme in filmes)
                {
                    Usuario usuario = _usuarioService.GetById(filme.UsuarioId);
                    FilmeResponse filmeResponse = new FilmeResponse
                    {
                        Diretor = filme.Diretor,
                        Ano = filme.Ano,
                        Elenco = filme.Elenco,
                        Titulo = filme.Titulo,
                        Genero = filme.Genero,
                        Pais = filme.Pais,
                        Username = usuario.Username,
                        Classificacao = filme.Classificacao,
                        FilmeId = filme.Id,
                        Foto = filme.Foto
                    };
                    filmeResponses.Add(filmeResponse);

                }
                resposta.Sucesso = true;
                resposta.Resultado = filmeResponses;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil AprovarRecusarFilmes(Guid FilmeId, bool Aprovar)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Filme filme = _filmeService.GetById(FilmeId);
                if (filme == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este filme não existe";
                    return resposta;
                }
                if (Aprovar)
                {
                    filme.Status = StatusAvaliacao.Aprovado;
                    _filmeService.Edit(filme);
                    resposta.Resultado = "Filme aprovada!";
                }
                if (!Aprovar)
                {
                    filme.Status = StatusAvaliacao.Rejeitado;
                    _filmeService.Edit(filme);
                    resposta.Resultado = "Filme recusada!";
                }
                resposta.Sucesso = true;

            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                resposta.Sucesso = false;
            }
            return resposta;
        }

        //Livro
        public ResponseUtil GetLivrosParaAprovacao()
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                var livros = _livroService.GetLivrosParaAprovacao();
                if (livros == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum livro cadastrado";
                    return resposta;
                };

                List<LivroResponse> livroResponses = new List<LivroResponse>();
                foreach (var livro in livros)
                {
                    Usuario usuario = _usuarioService.GetById(livro.UsuarioId);
                    LivroResponse livroResponse = new LivroResponse
                    {
                        Autores = livro.Autores,
                        Ano = livro.Ano,
                        Editora = livro.Editora,
                        Titulo = livro.Titulo,
                        Genero = livro.Genero,
                        Pais = livro.Pais,
                        Username = usuario.Username,
                        Classificacao = livro.Classificacao,
                        Id = livro.Id,
                        Foto = livro.Foto
                    };
                    livroResponses.Add(livroResponse);

                }
                resposta.Sucesso = true;
                resposta.Resultado = livroResponses;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil AprovarRecusarLivro(Guid LivroId, bool Aprovar)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Livro livro = _livroService.GetById(LivroId);
                if (livro == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este livro não existe";
                    return resposta;
                }
                if (Aprovar)
                {
                    livro.Status = StatusAvaliacao.Aprovado;
                    _livroService.Edit(livro);
                    resposta.Resultado = "Livro aprovada!";
                }
                if (!Aprovar)
                {
                    livro.Status = StatusAvaliacao.Rejeitado;
                    _livroService.Edit(livro);
                    resposta.Resultado = "Livro recusada!";
                }
                resposta.Sucesso = true;

            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                resposta.Sucesso = false;
            }
            return resposta;
        }
    }
}
