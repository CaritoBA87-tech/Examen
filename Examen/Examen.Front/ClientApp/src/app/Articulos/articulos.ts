export interface Articulo {
  id: number;
  codigo: string;
  descripcion: string;
  precio: string;
  imagen: string;
  stock: number;
  tiendasIDs: number[];
  articulosTiendas: ArticuloTienda[];
}

export interface ArticuloTienda {
  articuloID: number;
  tiendaId: number;
}
