import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';


import Person from './component/Person.js'
import AddPerson from './component/AddPerson.js'
function App() {
  return (
<>
<BrowserRouter>
        <Routes>
          <Route index element={<Person />} />
          <Route path='/Person' exact element={<Person />} />
        </Routes>
</BrowserRouter>
</>
  );
}

export default App;
