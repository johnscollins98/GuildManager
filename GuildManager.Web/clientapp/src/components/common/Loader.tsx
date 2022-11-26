import { FC, HTMLAttributes } from 'react';

interface LoaderProps extends HTMLAttributes<HTMLDivElement> {
  
}
 
const Loader: FC<LoaderProps> = (props) => {
  return (<div className='flex flex-1 justify-center items-center'>
    <div className='spinner-border animate-spin w-8 h-8 border-4 border-slate-400 border-l-slate-700 dark:border-slate-700 dark:border-l-slate-400 rounded-full' />
  </div>);
}
 
export default Loader;