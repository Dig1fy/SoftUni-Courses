import React, { useState, useContext } from 'react'
import styles from './login.module.css'
import PageLayout from '../../components/layout/layout'
import Title from '../../components/title/title'
import SubmitButton from '../../components/submitButton/submitButton'
import Input from '../../components/input/input'
import { useHistory } from 'react-router-dom'
import authenticate from '../../helper-functions/fetchRequests/authenticate'
import UserContext from '../../Context'

const LoginPage = () => {
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    let history = useHistory();
    let context = useContext(UserContext);

    const handleSubmit = async (e) => {
        e.preventDefault();
        let body = { username, password };

        let onSuccess = (user) => {
            // debugger
            console.log("LOGIN ACTUALLY WORKED!!!");
            // console.log(user);
            // That's why we implemented App like that
            context.logIn(() => user)
            history.push("/")
        }

        let onFailure = (e) => {
            console.log("ERROR: ", e);
        }
        await authenticate("http://localhost:9999/api/user/login", body, onSuccess, onFailure)

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