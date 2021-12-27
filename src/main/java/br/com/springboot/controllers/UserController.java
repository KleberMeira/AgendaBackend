package br.com.springboot.controllers;

import br.com.springboot.model.User;
import br.com.springboot.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/users")

public class UserController {

    private List<User> users = new ArrayList<>();

    @Autowired
    private UserRepository userRepository;

    @GetMapping("/")
    public User user(){

        User user = new User();
        user.setId(1L);
        user.setName("Kleber");
        user.setUsername("kleber.meira");
        return user;
    }

    @GetMapping("/{id}")
    public User userPorId(@PathVariable("id") Long id){

        //Optional<User> userFind = users.stream().filter(user -> user.getId() == id).findFirst();
        Optional<User> userFind = this.userRepository.findById(id);

        if(userFind.isPresent()){
            return userFind.get();
        }

        return null;

    }

    @PostMapping("/")
    public User user(@RequestBody User user){
        return this.userRepository.save(user);
    }

    @GetMapping("/list")
    public List<User> list(){
        return this.userRepository.findAll();
    }

    @GetMapping("/list/{id}")
    public List<User> list(@PathVariable("id") Long id){
        return this.userRepository.findAllMoreThan(id);
    }

}
