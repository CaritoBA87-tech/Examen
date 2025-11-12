export interface Articulo {
  id: number;
  codigo: string;
  descripcion: string;
  precio: number;
  imagen: string;
  stock: number;
  tiendasIDs: number[];
  articulosTiendas: ArticuloTienda[];
}

export interface ArticuloTienda {
  articuloID: number;
  tiendaId: number;
  stock: number;
}
