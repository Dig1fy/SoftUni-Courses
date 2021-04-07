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

        let body = { username, password }
        let onSuccess = (user) => {
            context.logIn(user)
            history.push("/")
        }
        let onFailure = (e) => {
            console.log("ERROR: ", e)
        }

        await authenticate("http://localhost:9999/api/user/register", body, onSuccess, onFailure)
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
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>
                <div>
                    <Input
                        type="password"
                        labelContent="Password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div>
                    <Input
                        type="password"
                        labelContent="Re-password"
                        id="rePassword"
                        value={rePassword}
                        onChange={(e) => setRePassword(e.target.value)}
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