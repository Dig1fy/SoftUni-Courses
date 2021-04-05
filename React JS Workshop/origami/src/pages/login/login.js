import React, { useState } from 'react'
import styles from './login.module.css'
import PageLayout from '../../components/layout/layout'
import Title from '../../components/title/title'
import SubmitButton from '../../components/submitButton/submitButton'
import Input from '../../components/input/input'
import {useHistory} from 'react-router-dom'

const LoginPage = () => {
    const history = useHistory();
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    async function handleSubmit(e) {
        e.preventDefault();

        try {
            const promise = await fetch('http://localhost:9999/api/user/login', {
                method: "post",
                //Depends how it's been configured in our restApi
                body: JSON.stringify({
                    username: username,
                    password: password
                }),
                headers: {
                    "Content-Type": "application/json"
                }
            })

            // console.log(promise);
            //we access the cookie from the response like this: promise.headers.get("Authorization")
            const authorizationCookie = promise.headers.get("Authorization")
            document.cookie = `x-auth-token= ${authorizationCookie}`
            const response = await promise.json()

            if(response.username && authorizationCookie){
               history.push("/");
            }

        } catch (e) {
            console.log(e);
        }
    }

    const changeUsername = (event) => {
        setUsername(event.target.value)
    }

    const changePassword = (event) => {
        setPassword(event.target.value)
    }

    return (
        <PageLayout>
            <Title title="Login" />
            <form className={styles.container} onSubmit={(e) => handleSubmit(e)}>
                <div>
                    <Input
                        labelContent="Username"
                        id="username"
                        value={username}
                        onChange={(e) => changeUsername(e)}
                    />
                </div>
                <div>
                    <Input
                        type="password"
                        labelContent="Password"
                        id="password"
                        value={password}
                        onChange={(e) => changePassword(e)}
                    />
                </div>
                <div>
                    <SubmitButton buttonValue="Submit" />
                </div>
            </form>
        </PageLayout>
    )
}

export default LoginPage