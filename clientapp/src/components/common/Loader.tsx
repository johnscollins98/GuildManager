import { FC } from 'react';
import './Loader.scss';

interface LoaderProps {
  
}
 
const Loader: FC<LoaderProps> = () => {
  return (<div className="loader">
    <span className='spinner-border' />
  </div>);
}
 
export default Loader;