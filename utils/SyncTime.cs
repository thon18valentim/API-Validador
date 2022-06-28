namespace ValidadorAPI.utils
{
  public static class SyncTime
  {
    public static float CristianSyncTime(float tempoRecebido, float horarioRequisicao, float horarioRecebimento)
    {
      return tempoRecebido + (horarioRecebimento - horarioRequisicao) / 2;
    }
  }
}
