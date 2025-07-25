﻿namespace Poc.NfseIntegracao.App.Data
{
    public class TemplateXml
    {
        public static string XmlExemplo = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<NFSe xmlns=""http://www.sped.fazenda.gov.br/nfse"" versao=""1.00"">
  <infNFSe Id=""NSF00"">
    <xLocEmi>Regente Feijó</xLocEmi>
    <xLocPrestacao>Regente Feijó</xLocPrestacao>
    <nNFSe>1</nNFSe>
    <cLocIncid>3542404</cLocIncid>
    <xLocIncid>Regente Feijó</xLocIncid>
    <xTribNac>Lubrificação, limpeza, lustração, revisão, carga e recarga, conserto, restauração, blindagem, manutenção e conservação de máquinas, veículos, aparelhos, equipamentos, motores, elevadores ou de qualquer objeto (exceto peças e partes empregadas, que ficam sujeitas ao ICMS).</xTribNac>
    <xTribMun>Lubrificação, limpeza, lustração, revisã</xTribMun>
    <verAplic>1.00</verAplic>
    <ambGer>1</ambGer>
    <tpEmis>2</tpEmis>
    <cStat>100</cStat>
    <dhProc>2025-06-20T00:00:00-05:00</dhProc>
    <nDFSe>1</nDFSe>
    <emit>
      <CNPJ>0000000000000</CNPJ>
      <IM>4292</IM>
      <xNome>Empresa de Teste 01</xNome>
      <xFant>Empresa de Teste 01</xFant>
      <enderNac>
        <xLgr>AV. ATILIO ALBERTINI</xLgr>
        <nro>0</nro>
        <xCpl>S/N - PARTE</xCpl>
        <xBairro>DISTRITO INDUSTRIAL</xBairro>
        <cMun>3542404</cMun>
        <UF>SP</UF>
        <CEP>19570000</CEP>
      </enderNac>
      <fone>1832296800</fone>
      <email>teste@teste.com.br</email>
    </emit>
    <valores>
      <vCalcDR>0.00</vCalcDR>
      <vCalcBM>0.00</vCalcBM>
      <vBC>1623.03</vBC>
      <pAliqAplic>3.00</pAliqAplic>
      <vISSQN>48.69</vISSQN>
      <vTotalRet>0.00</vTotalRet>
      <vLiq>1623.03</vLiq>
    </valores>
    <DPS xmlns=""http://www.sped.fazenda.gov.br/nfse"" versao=""1.00"">
      <infDPS Id=""DPS00"">
        <tpAmb>2</tpAmb>
        <dhEmi>2025-06-20T00:00:00-05:00</dhEmi>
        <verAplic>1.00</verAplic>
        <serie>00001</serie>
        <nDPS>1</nDPS>
        <dCompet>2025-06-20</dCompet>
        <tpEmit>1</tpEmit>
        <cLocEmi>3542404</cLocEmi>
        <prest>
          <CNPJ>0000000000000</CNPJ>
          <IM>4292</IM>
          <xNome>Empresa de Teste 01</xNome>
          <end>
            <endNac>
              <cMun>3542404</cMun>
              <CEP>19570000</CEP>
            </endNac>
            <xLgr>AV. ATILIO ALBERTINI</xLgr>
            <nro>0</nro>
            <xCpl>S/N - PARTE</xCpl>
            <xBairro>DISTRITO INDUSTRIAL</xBairro>
          </end>
          <regTrib>
            <opSimpNac>1</opSimpNac>
            <regEspTrib>0</regEspTrib>
          </regTrib>
        </prest>
        <toma>
          <CNPJ>43999424000114</CNPJ>
          <xNome>VOLVO DO BRASIL VEICULOS LTDA</xNome>
          <end>
            <endNac>
              <cMun>4106902</cMun>
              <CEP>81260900</CEP>
            </endNac>
            <xLgr>AV JUSCELINO K. DE OLIVEIRA</xLgr>
            <nro>2600</nro>
            <xBairro>CIDADE INDUSTRIAL DE</xBairro>
          </end>
        </toma>
        <serv>
          <locPrest>
            <cLocPrestacao>3542404</cLocPrestacao>
          </locPrest>
          <cServ>
            <cTribNac>140101</cTribNac>
            <xDescServ>Lubrificação, limpeza, lustração, revisão, carga e recarga, conserto, restauração, blindagem, manutenção e conservação de máquinas, veículos, aparelhos, equipamentos, motores, elevadores ou de qualquer objeto (exceto peças e partes empregadas, que ficam sujeitas ao ICMS).</xDescServ>
          </cServ>
        </serv>
        <valores>
          <vServPrest>
            <vServ>1623.03</vServ>
          </vServPrest>
          <vDescCondIncond>
            <vDescIncond>0.00</vDescIncond>
            <vDescCond>0.00</vDescCond>
          </vDescCondIncond>
          <vDedRed>
            <vDR>0.00</vDR>
          </vDedRed>
          <trib>
            <tribMun>
              <tribISSQN>1</tribISSQN>
              <pAliq>3.00</pAliq>
              <tpRetISSQN>1</tpRetISSQN>
            </tribMun>
            <tribFed>
              <piscofins>
                <CST>00</CST>
                <vPis>0.00</vPis>
                <vCofins>0.00</vCofins>
              </piscofins>
              <vRetCP>0.00</vRetCP>
              <vRetIRRF>0.00</vRetIRRF>
              <vRetCSLL>0.00</vRetCSLL>
            </tribFed>
            <totTrib>
              <vTotTrib>
                <vTotTribFed>0.00</vTotTribFed>
                <vTotTribEst>0.00</vTotTribEst>
                <vTotTribMun>0.60</vTotTribMun>
              </vTotTrib>
            </totTrib>
          </trib>
        </valores>
      </infDPS>
    </DPS>
  </infNFSe>
</NFSe>";
    }
}
