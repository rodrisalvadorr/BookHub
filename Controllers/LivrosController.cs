using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using LibraryMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
  public class LivrosController : Controller
  {
    public string uriBase = "http://rodrisalvadorr.somee.com/LibraryAPI/Livros/";

    [HttpGet]
    public async Task<ActionResult> IndexAsync()
    {
      try
      {
        string uriComplementar = "GetAll";
        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
        string serialized = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          List<LivroViewModel> listaPersonagens = await Task.Run(() =>
            JsonConvert.DeserializeObject<List<LivroViewModel>>(serialized));

          return View(listaPersonagens);
        }
        else
          throw new System.Exception(serialized);
      }
      catch (System.Exception ex)
      {
        TempData["MensagemErro"] = ex.Message;
        return RedirectToAction("Index");
      }
    }

    [HttpGet]
    public async Task<ActionResult> DetailsAsync(int id)
    {
      try
      {
        HttpClient httpClient = new HttpClient();
        
        HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString());
        string serialized = await response.Content.ReadAsStringAsync();
        
        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          LivroViewModel livro = await Task.Run(() =>
          JsonConvert.DeserializeObject<LivroViewModel>(serialized));
          
          return View(livro);
        }
        else
        {
          throw new System.Exception(serialized);
        }
      }
      catch (System.Exception ex)
      {
        TempData["MensagemErro"] = ex.Message;
        return RedirectToAction("Index");
      }
    }

    [HttpGet]
    public async Task<ActionResult> EditAsync(int id)
    {
      try
      {
        HttpClient httpClient = new HttpClient();
        
        HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString());
        string serialized = await response.Content.ReadAsStringAsync();
        
        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          LivroViewModel livro = await Task.Run(() =>
          JsonConvert.DeserializeObject<LivroViewModel>(serialized));
          
          return View(livro);
        }
        else
        {
          throw new System.Exception(serialized);
        }
      }
      catch (System.Exception ex)
      {
        TempData["MensagemErro"] = ex.Message;
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public async Task<ActionResult> EditAsync(LivroViewModel livro)
    {
      try
      {  
        HttpClient httpClient = new HttpClient();

        var content = new StringContent(JsonConvert.SerializeObject(livro));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
  
        HttpResponseMessage response = await httpClient.PutAsync(uriBase, content);

        string serialized = await response.Content.ReadAsStringAsync();

        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          TempData["Mensagem"] =
            string.Format("Personagem {0} atualizado com sucesso!", livro.Titulo);

            return RedirectToAction("Details");
        }
        else
        {
          throw new System.Exception(serialized);
        }
      }
      catch (System.Exception ex)
      {
        TempData["MensagemErro"] = ex.Message;
        return RedirectToAction("Index");
      }
    }

    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        HttpClient httpClient = new HttpClient();
        
        HttpResponseMessage response = await httpClient.DeleteAsync(uriBase + id.ToString());
        string serialized = await response.Content.ReadAsStringAsync();
        
        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          TempData["Mensagem"] =
          string.Format("Livro {0} removido com sucesso", id);
          
          return RedirectToAction("Index");
        }
        else
        {
          throw new System.Exception(serialized);
        }
      }
      catch (System.Exception ex)
      {
        TempData["MensagemErro"] = ex.Message;
        return RedirectToAction("Index");
      }
    }

    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(LivroViewModel livro)
    {
      try
      {  
        HttpClient httpClient = new HttpClient();

        var content = new StringContent(JsonConvert.SerializeObject(livro));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
  
        HttpResponseMessage response = await httpClient.PutAsync(uriBase, content);

        string serialized = await response.Content.ReadAsStringAsync();

        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          TempData["Mensagem"] =
            string.Format("Personagem {0} incluído com sucesso!", livro.Titulo);

            return RedirectToAction("Index");
        }
        else
        {
          throw new System.Exception(serialized);
        }
      }
      catch (System.Exception ex)
      {
        TempData["MensagemErro"] = ex.Message;
        return RedirectToAction("Index");
      }
    }
  }
}