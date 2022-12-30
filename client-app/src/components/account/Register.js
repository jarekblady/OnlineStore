import React, { useState } from 'react'
import { Button, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export default function Login() {
    const [validationFirstName, setValidationFirstName] = useState();
    const [validationLastName, setValidationLastName] = useState();
    const [validationEmail, setValidationEmail] = useState();
    const [validationPassword, setValidationPassword] = useState();


    function handleSubmit(event) {
        event.preventDefault();
        fetch('http://localhost:7204/api/account/register', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: event.target.email.value,
                password: event.target.password.value,
                firstName: event.target.firstName.value,
                lastName: event.target.lastName.value,
            })
        })
            .then(res => res.json())
            .then((result) => {
                validation(result.errors)
            })
    };
    function validation(e) {
        e.FirstName !== undefined ? setValidationFirstName(e.FirstName[0]) : setValidationFirstName()
        e.LastName !== undefined ? setValidationLastName(e.LastName[0]) : setValidationLastName()
        e.Email !== undefined ? setValidationEmail(e.Email[0]) : setValidationEmail()
        e.Password !== undefined ? setValidationPassword(e.Password[0]) : setValidationPassword()

    };

    return (
        <>
            <div className="text-center mb-4">
                <h1 className="display-4">Register</h1>
            </div>
            <div className="d-flex justify-content-center">
                <Form className="w-25" onSubmit={handleSubmit}>
                    <Form.Group controlId="firstName">
                        <Form.Label>FirstName</Form.Label>
                        <Form.Control className="mb-2"
                            type="text"
                            placeholder="FirstName"
                            name="firstName"
                        />
                        <p class="text-danger">{validationFirstName}</p>
                    </Form.Group>
                    <Form.Group controlId="lastName">
                        <Form.Label>LastName</Form.Label>
                        <Form.Control className="mb-2"
                            type="text"
                            placeholder="LastName"
                            name="lastName"
                        />
                        <p class="text-danger">{validationLastName}</p>
                    </Form.Group>
                    <Form.Group controlId="email">
                        <Form.Label>Email</Form.Label>
                        <Form.Control className="mb-2"
                            type="text"
                            placeholder="email"
                            name="email"
                        />
                        <p class="text-danger">{validationEmail}</p>
                    </Form.Group>
                    <Form.Group controlId="password">
                        <Form.Label>Password</Form.Label>
                        <Form.Control className="mb-2"
                            type="password"
                            placeholder="password"
                            name="password"
                        />
                        <p class="text-danger">{validationPassword}</p>
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Register
                    </Button>
                </Form>
            </div>
            <div className="text-center mb-4">
                <div>
                    <Link to='/login'>
                        {"Already have an account? Sign In"}
                    </Link>
                </div>
            </div>
        </>
    )

}