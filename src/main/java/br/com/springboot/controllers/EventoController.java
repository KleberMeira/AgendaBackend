package br.com.springboot.controllers;

import br.com.springboot.model.Evento;
import br.com.springboot.model.User;
import br.com.springboot.repository.EventoRepository;
import br.com.springboot.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/evento")

public class EventoController {

    private List<Evento> eventos = new ArrayList<>();

    @Autowired
    private EventoRepository eventoRepository;

    @PostMapping("/")
    public Evento evento(@RequestBody Evento evento){
        return this.eventoRepository.save(evento);
    }

    @GetMapping("/list")
    public List<Evento> list(){
        return eventoRepository.findAll();
    }

    @GetMapping("/evento/{id}")
    public List<Evento> list(@PathVariable("id") Long id){
        return this.eventoRepository.buscarUmEventoPorId(id);
    }

}
