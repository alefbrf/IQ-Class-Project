import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/Dashboard/Home';
import Dashboard from './pages/Dashboard';
import Authentication from './pages/Authentication';
import Authentication1 from './pages/Authentication';

export default function AppRouter() {

    const logado = false;

    return (
        <main>
            <Router>
                <Routes>
                    {logado ?
                        <Route path='/'>
                            <Route index element={<Home />} />
                            <Route path='dashboard' element={<Dashboard />} />
                        </Route>
                        :
                        <Route path='/'>
                            <Route index element={<Authentication />} />
                        </Route>
                    }
                </Routes>
            </Router>
        </main>
    )
}