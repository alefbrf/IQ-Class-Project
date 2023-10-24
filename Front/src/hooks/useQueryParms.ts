import { useLocation } from 'react-router-dom'

export function useQueryParams<T extends Object>(): T {
  const params = new URLSearchParams(useLocation().search)

  let data: { [key: string]: any } = {}

  for (const key of params.keys()) {
    data[key] = params.get(key)
  }

  return data as T
}