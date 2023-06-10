import React, { useState } from 'react';
import { Container, Header, Input, Button, List, Menu } from 'semantic-ui-react';
import { TodoItemType } from './types/TodoItemType';

const TodoApp: React.FC = () => {
  const [todos, setTodos] = useState<TodoItemType[]>([]);
  const [newTodo, setNewTodo] = useState('');
  const [activeSection, setActiveSection] = useState('incomplete');
  const [idCounter, setIdCounter] = useState(1);
  const [sortOrder, setSortOrder] = useState<'asc' | 'desc'>('asc');


  const addTodo = () => {
    if (newTodo.trim() === '') {
      return;
    }
    const todo: TodoItemType = {
      id: idCounter,
      task: newTodo,
      createdDate: new Date(),
      isCompleted: false,
    };
    setTodos([...todos, todo]);
    setNewTodo('');
    setIdCounter(idCounter + 1)
  };

  const removeTodo = (id: number) => {
    const updatedTodos = todos.filter((todo) => todo.id !== id);
    setTodos(updatedTodos);
  };

  const toggleComplete = (id: number) => {
    const updatedTodos = todos.map((todo) =>
      todo.id === id ? { ...todo, isCompleted: true } : todo
    );
    setTodos(updatedTodos);
  };

  const sortTodos = () => {
    const sortedTodos = [...todos].sort((a, b) => {
      if (sortOrder === 'asc') {
        return a.createdDate.getTime() - b.createdDate.getTime();
      } else {
        return b.createdDate.getTime() - a.createdDate.getTime();
      }
    });
    setTodos(sortedTodos);
    setSortOrder(sortOrder === 'asc' ? 'desc' : 'asc');
  };

  return (
    <div style={{
      display: 'flex',  justifyContent: 'center',  background: 'url("/backgroundBasic.jpg")',
      backgroundSize: 'cover',
      minHeight: '100vh',
    }}>
      <Container>
        <Header style={{ display: 'flex', marginBlock:"5%", justifyContent: 'center',color:"gray" }} as="h1">Todo App</Header>
        <Input
          fluid
          placeholder="Enter a new todo..."
          value={newTodo}
          onChange={(e) => setNewTodo(e.target.value)}
          action={<Button primary basic onClick={addTodo}>Add Todo</Button>}
        />
        <Menu pointing secondary>
          <Menu.Item
            name="Todos"
            active={activeSection === 'incomplete' || activeSection === 'completed'}
            onClick={() => setActiveSection('incomplete')}
          />
          <Menu.Menu position="right">
            <Menu.Item>
              <Button onClick={sortTodos}>
                {sortOrder === 'asc' ? 'Sort Ascending' : 'Sort Descending'}
              </Button>
            </Menu.Item>
          </Menu.Menu>
        </Menu>
        <List divided relaxed>
          {todos.map((todo) => (
            <List.Item key={todo.id}
              onDoubleClick={() => toggleComplete(todo.id)}
              style={{ cursor: "pointer", textDecoration: todo.isCompleted ? 'line-through' : 'none' }}>
              <List.Content floated="right">
                <Button
                  negative basic
                  onClick={() => removeTodo(todo.id)}
                >
                  Delete
                </Button>
              </List.Content>
              <List.Content>{todo.task}</List.Content>
            </List.Item>
          ))}
        </List>
      </Container>
    </div>
  );
};

export default TodoApp;
