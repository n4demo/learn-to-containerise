package main

import (
	"fmt"
	"net/http"
	"os"
)

func getEnv(key, fallback string) string {
	value, exists := os.LookupEnv(key)
	if !exists {
		value = fallback
	}
	return value
}

func main() {
	port := getEnv("PORT", "80")



	
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprintf(w, "This is a Go executable ruinning in a container!!")
	})

	http.ListenAndServe(":"+port, nil)
}
