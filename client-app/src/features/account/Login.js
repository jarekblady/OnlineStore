import React, { useState } from 'react'
import { Button, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { useStoreContext } from "../../context/StoreContext";

export default function Login() {
    const { user, setUser } = useStoreContext();
    const [error, setError] = useState();


    function handleSubmit(event) {
        setUser();
        event.preventDefault();
        fetch('http://localhost:7204/api/account/login', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: event.target.email.value,
                password: event.target.password.value,
            })
        })
            .then(res => res.json())
            .then((result) => {
                setUser(result)               
            })
        !user ? setError("Incorrect e-mail or password") : setError()
    };



    return (
        <>
            <div className="text-center mb-4">
                <h1 className="display-4">Sign in</h1>
            </div>
            <div className="d-flex justify-content-center">
                <Form className="w-25" onSubmit={handleSubmit}>
                    <Form.Group controlId="email">
                        <Form.Label>Email</Form.Label>
                        <Form.Control className="mb-2"
                            type="email"
                            placeholder="email"
                            name="email"
                            required
                        />
                    </Form.Group>
                    <Form.Group controlId="password">
                        <Form.Label>Password</Form.Label>
                        <Form.Control className="mb-2"
                            type="password"
                            placeholder="password"
                            name="password"
                            required
                        />
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Sign in
                    </Button>
                    <div className="text-danger">
                        <p>{error}</p>
                    </div>
                </Form>
            </div>
            <div className="text-center mb-4">
                <div>
                    <Link to='/register'>
                        {"Don't have an account? Sign Up"}
                    </Link>
                </div>
            </div>
        </>
    )

}