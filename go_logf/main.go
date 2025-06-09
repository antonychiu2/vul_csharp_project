package main

import (
	"log"
	"net/http"
)

func serve() {
	http.HandleFunc("/register", func(w http.ResponseWriter, r *http.Request) {
		r.ParseForm()
		user := r.Form.Get("user")

		log.Printf("Register user: %v\n", user)
	})
	http.ListenAndServe(":80", nil)
}

func main() {
}
