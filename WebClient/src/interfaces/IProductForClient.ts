import {IBaseEntity} from "./IBaseEntity";
import {IProduct} from "./IProduct";
import {IClient} from "./IClient";
import {IProductService} from "./IProductService";


export interface IProductForClient extends IBaseEntity{
  "productId": number,
  "product": IProduct,
  "clientId": number,
  "client": IClient,
  "count": number,
  "productServices": IProductService[]
}
