import { FC, HTMLAttributes } from 'react';
import './Loader.scss';

interface LoaderProps extends HTMLAttributes<HTMLDivElement> {
  
}
 
const Loader: FC<LoaderProps> = ({ className, ...props }) => {
  return (<div className={`loader ${className ?? ''}`} {...props}>
    <span className='spinner-border' />
  </div>);
}
 
export default Loader;