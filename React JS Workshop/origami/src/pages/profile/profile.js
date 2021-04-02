import React, { useState, useEffect } from 'react'
import PageLayout from '../../components/layout/layout'
import Posts from '../../components/posts/posts'
import { useParams, useHistory } from 'react-router-dom'
import SubmitButton from '../../components/submitButton/submitButton'

const ProfilePage = (props) => {
    const [username, setUsername] = useState(null)
    const [posts, setPosts] = useState(null)
    const history = useHistory();

    const params = useParams()
  console.log(props.match.params);

    const logOut = () => {
        history.push('/')
    }

    const getUser = async () => {
        const id = '22'

        const promise = await fetch(`http://localhost:9999/api/user?_id=${id}`)
        if (!promise) {
            history.push("/error")
        }
        const user = await promise.json();

        if (!user) {
            history.push("/error")
        } else {
            setUsername(user.username)
            setPosts(user.posts && user.posts.length)
        }
    }

    useEffect(() => {

        getUser()
    }, [getUser])

    return (
        <PageLayout>
            <div>
                <p>User: {username}</p>
                <p>Posts: {posts}</p>

                <SubmitButton buttonValue="Logout" onClick={() => logOut()} />
            </div>
            <Posts length={3} />
        </PageLayout>
    )
}

export default ProfilePage