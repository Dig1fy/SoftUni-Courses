import React, { useState } from 'react'
import styles from './register.module.css'
import PageLayout from '../../components/layout/layout'
import Title from '../../components/title/title'
import SubmitButton from '../../components/submitButton/submitButton'
import Input from '../../components/input/input'
import { useHistory } from 'react-router-dom'
import authenticate from '../../helper-functions/fetchRequests/authenticate'
import UserContext from '../../Context'

const RegisterPage = () => {
    const history = useHistory();
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    const [rePassword, setRePassword] = useState('')

    const handleSubmit = async (e) => {
        e.preventDefault();
        const context = UserContext;

        let body = { username, password };
        let onSuccess = (user) => {
            console.log("REGISTER ACTUALLY WORKED!!!");
            context.logIn(user)
            alert(context.user)
            history.push("/")
        }
        let onFailure = (e) => {
            console.log("ERROR: ", e);
        }
        await authenticate("http://localhost:9999/api/user/register", body, onSuccess, onFailure)
        
    }


    const changeUsername = (event) => {
        setUsername(event.target.value)
    }

    const changePassword = (event) => {
        setPassword(event.target.value)
    }

    const changeRePassword = (event) => {
        setRePassword(event.target.value)
    }

    return (
        <PageLayout>
            <Title title="Register" />
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
                    <Input
                        type="password"
                        labelContent="Re-password"
                        id="rePassword"
                        value={rePassword}
                        onChange={(e) => changeRePassword(e)}
                    />
                </div>
                <div>
                    <SubmitButton buttonValue="Submit" />
                </div>
            </form>
        </PageLayout>
    )
}

export default RegisterPage