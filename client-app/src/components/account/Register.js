import React, { useState } from 'react'
import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Button from '@mui/material/Button';
import { Paper } from '@mui/material';
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
        <Container component={Paper} maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4 }}>
            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                <LockOutlinedIcon />
            </Avatar>
            <Typography component="h1" variant="h5">
                Register
            </Typography>
            <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    id="email"
                    label="Email Address"
                    name="email"
                    error={validationEmail}
                    helperText={validationEmail}
                />
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    name="password"
                    label="Password"
                    type="password"
                    id="password"
                    error={validationPassword}
                    helperText={validationPassword}
                />
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    id="firstName"
                    label="FirstName"
                    name="firstName"
                    error={validationFirstName}
                    helperText={validationFirstName}
                />
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    id="lastName"
                    label="LastName"
                    name="lastName"
                    error={validationLastName}
                    helperText={validationLastName}
                />
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                >
                    Register
                </Button>
                <Grid container>
                    <Grid item>
                        <Link to='/login'>
                            {"Already have an account? Sign In"}
                        </Link>
                    </Grid>
                </Grid>
            </Box>
        </Container>
    );
}