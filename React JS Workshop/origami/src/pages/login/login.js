import React, { useState } from 'react'
import styles from './login.module.css'
import PageLayout from '../../components/layout/layout'
import Title from '../../components/title/title'
import SubmitButton from '../../components/submitButton/submitButton'
import Input from '../../components/input/input'

const LoginPage = () => {
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    function handleSubmit(e) {
        e.preventDefault();
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