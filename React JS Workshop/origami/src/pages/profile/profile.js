import React, { useState, useEffect, useContext, useCallback } from 'react'
import PageLayout from '../../components/layout/layout'
import Posts from '../../components/posts/posts'
import { useParams, useHistory } from 'react-router-dom'
import SubmitButton from '../../components/submitButton/submitButton'
import UserContext from '../../Context'

const ProfilePage = (props) => {
    const [username, setUsername] = useState(null)
    const [posts, setPosts] = useState(null)
    const history = useHistory();
    const context = useContext(UserContext)
    const params = useParams();

    console.log(props.match.params, "PARAMS");

    const logOut = () => {
        context.logOut()
        history.push('/')
    }

    const getData = useCallback(async () => {
        const id = context.user.id
        const response = await fetch(`http://localhost:9999/api/user?id=${id}`)

        if (!response.ok) {
            history.push("/error")
        } else {
            const user = await response.json();
            setUsername(user.username)
            setPosts(user.posts && user.posts.length)
        }

    }, [params.userid, history])



    useEffect(() => {
        getData()
    }, [getData])

    if (!username) {
        return (
            <PageLayout>
                <div>.............Loading.............</div>
            </PageLayout>
        )
    }

    return (
        <PageLayout>
            <div>
                <p>User: {username}</p>
                <p>Posts: {posts}</p>

                <button onClick={logOut}>Logout</button>
            </div>
            <Posts length={3} />

        </PageLayout>
    )
}

export default ProfilePage