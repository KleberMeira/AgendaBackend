package br.com.springboot.repository;

import br.com.springboot.model.Evento;
import br.com.springboot.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface EventoRepository extends JpaRepository<Evento, Long> {

    @Query("SELECT e from Evento e ")
    public List<Evento> listarTodosEventos();

    @Query("SELECT e from Evento e where e.id = :id")
    public List<Evento> buscarUmEventoPorId(@Param("id") Long id);


}
